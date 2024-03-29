﻿using AutoMapper;
using Bonyan.Bnb.Collections;
using Bonyan.Bnb.Extensions;

namespace Bonyan.BNB.AutoMapper;

public class BnbAutoMapperOptions
{
    public List<Action<IBnbAutoMapperConfigurationContext>> Configurators { get; }

    public ITypeList<Profile> ValidatingProfiles { get; set; }

    public BnbAutoMapperOptions()
    {
        Configurators = new List<Action<IBnbAutoMapperConfigurationContext>>();
        ValidatingProfiles = new TypeList<Profile>();
    }

    public void AddMaps<TModule>(bool validate = false)
    {
        var assembly = typeof(TModule).Assembly;

        Configurators.Add(context =>
        {
            context.MapperConfiguration.AddMaps(assembly);
        });

        if (validate)
        {
            var profileTypes = assembly
                .DefinedTypes
                .Where(type => typeof(Profile).IsAssignableFrom(type) && !type.IsAbstract && !type.IsGenericType);

            foreach (var profileType in profileTypes)
            {
                ValidatingProfiles.Add(profileType);
            }
        }
    }

    public void AddProfile<TProfile>(bool validate = false)
        where TProfile : Profile, new()
    {
        Configurators.Add(context =>
        {
            context.MapperConfiguration.AddProfile<TProfile>();
        });

        if (validate)
        {
            ValidateProfile(typeof(TProfile));
        }
    }

    public void ValidateProfile<TProfile>(bool validate = true)
        where TProfile : Profile
    {
        ValidateProfile(typeof(TProfile), validate);
    }

    public void ValidateProfile(Type profileType, bool validate = true)
    {
        if (validate)
        {
            ValidatingProfiles.AddIfNotContains(profileType);
        }
        else
        {
            ValidatingProfiles.Remove(profileType);
        }
    }
}
