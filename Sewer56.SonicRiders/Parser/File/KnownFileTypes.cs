using System;
using Sewer56.SonicRiders.Parser.File.Structures;

namespace Sewer56.SonicRiders.Parser.File;

public static class KnownFileTypes
{
    public static readonly FileType[] Types = 
    {
        new()
        {
            Id = "DTPK",
            Category = "Audio Archive",
            Extension = ".DAT",
            Format = "XBOX DTPK",
            Tools = Array.Empty<Tool>(),
            Documentation = new Documentation[]
            {
                new("Dreamcast Variant [AM2-DTPK.txt]", "https://github.com/Shenmue-Mods/DTPKUtil/blob/master/AM2-DTPK.txt", "Sappharad")
            },
            Description = "Archive containing uncompressed audio. Variant of .SND used in Shenmue, alongside other games. Most likely PCM 16-bit, 1 Channel, 22050Hz audio; but there can sometimes be a mix of multiple frequencies. DTPKUtil may support the Xbox variant we use in the future.",
            Example = "00.dat"
        },
        new()
        {
            Id = "RIDERS-PACKMAN",
            Category = "Archive",
            Extension = "", // No extension
            Format = "Riders Archive",
            Tools = new Tool[]
            {
                new ("RidersArchiveTool", "https://github.com/Sewer56/SonicRiders.Index/tree/master/Source/RidersArchiveTool", "Sewer56", "Flawlessly extracts and repacks archives with 1:1 output."),
                new ("Sega NN Tools", "https://github.com/Argx2121/Sega_NN_tools", "Arg!!", "Unpacks certain variations of the formats in search of models.")
            },
            Documentation = new Documentation[] 
            {
                new ("PackMan.bt", "https://github.com/Sewer56/SonicRiders.Index/blob/master/docs/files/template/PackMan.bt", "Sewer56, Arg!!")
            },
            Description = "Sonic Riders' native archive format. Has optional compression and no extension.",
            Example = "1"
        },
        new()
        {
            Id = "ADX",
            Category = "Audio",
            Extension = ".ADX",
            Format = "CRI ADX",
            Tools = new Tool[]
            {
                new ("VGAudio", "https://github.com/Thealexbarney/VGAudio", "Alex Barney", "Recommended encoder."),
                new ("radx", "https://github.com/Isaac-Lozano/radx", "OnVar", "Open source encoder."),
                new ("AtomENCD", "https://gamebanana.com/tuts/13109", "DuIslingr", "GUI for the official CRI encoder."),
                new ("adxencd", "http://shenmuesubs.sourceforge.net/download/addons/CRI_Middleware_ADX_Tools_v1.15_Linux_Win32.rar", "adxencd", "The official CRI ADX encoder.")
            },
            Documentation = new Documentation[]
            {
                new ("adx.bt", "https://github.com/Sewer56/VGAudio/blob/master/docs/010-editor-templates/adx.bt", "Alex Barney, Sewer56"),
                new ("Wikipedia", "https://en.wikipedia.org/wiki/ADX_(file_format)", "Unknown")
            },
            Description = "Lossy proprietary audio format from CRI Middleware for low CPU audio playback.",
            Example = "E01E.ADX"
        },
        new()
        {
            Id = "AFS",
            Extension = ".AFS",
            Category = "Archive",
            Format = "CRI AFS",
            Tools = new Tool[]
            {
                new ("AFSUtils", "https://sourceforge.net/projects/shenmuesubs/files/AFS%20Utils/afsutils_23.7z/download", "Manic & Co.", "Yet another AFS packer/unpacker."),
                new ("AFS Explorer", "https://www.moddingway.com/file/270.html", "WE Team", "Ancient tool intended for PES games; but still commonly used."),
                new ("AFSPacker", "https://github.com/MaikelChan/AFSPacker", "MaikelChan", "More relatively modern tool for dealing with AFSes."),
                new ("SimpleAFSExtractor", "https://github.com/ShadowTheHedgehogHacking/SimpleAFSExtractor", "DreamSyntax & Sewer56", "Frontend for Sewer's AFS Library."),
            },
            Documentation = new Documentation[]
            {
                new Documentation("GRAF:AFS", "http://wiki.xentax.com/index.php/GRAF:AFS_AFS", "WATTO")
            },
            Description = "Proprietary archive from CRI Middleware which contains a collection of audio files in either ADX, AIX or AHX format (interchangeable). [Note: This is a generic data container, but in Riders is only used for audio]",
            Example = "Voice\\VOICE.AFS"
        },
        new()
        {
            Id = "AIX",
            Extension = ".AIX",
            Category = "Audio",
            Format = "CRI AIX",
            Tools = new Tool[]
            {
                new ("aixmaker", "http://shenmuesubs.sourceforge.net/download/addons/CRI_Middleware_ADX_Tools_v1.15_Linux_Win32.rar", "CRI Middleware", "Official CRI AIX Maker")
            },
            Description = "Proprietary audio format from CRI Middleware storing multiple ADX tracks in one file.",
            Example = "ED_E.AIX"
        },
        new()
        {
            Id = "SFD",
            Extension = ".SFD",
            Category = "Video",
            Format = "CRI SofDec",
            Tools = new Tool[]
            {
                new ("SofDec CRAFT", "https://archive.org/details/CRISDK113XB", "CRI Middleware", "Official CRI Encoder. Nobody seems to know about this one but it's the best one, so putting it first."),
                new ("SfdMux", "https://archive.org/details/CRISDK113XB", "CRI Middleware", "Creates SFD files from MPEG 1 Video and Audio. Tutorial: https://gamebanana.com/tuts/13387"),
            },
            Description = "Proprietary video format from CRI Middleware which is a wrapper for MPEG-1 (Riders) or MPEG-2 video, with ADX-encoded audio using MPEG-PS container.",
            Example = "ENDING.sfd"
        },
        new()
        {
            Id = "NN-XNF",
            Extension = ".XNF",
            Category = "3D",
            Format = "Sega NN: Morph Animation [Xbox/Direct3D]",
            Tools = Array.Empty<Tool>(),
            Documentation = new Documentation[]
            {
                new ("RadfordHound's NN Spec", "https://gist.github.com/Radfordhound/5650ef12209da2709a6bf9b705bdd79c", "RadfordHound")
            },
            Description = "",
            Example = "v.xnf"
        },
        new()
        {
            Id = "NN-XNG",
            Extension = ".XNG",
            Category = "3D",
            Format = "Sega NN: ?? Animation [Xbox/Direct3D]",
            Tools = Array.Empty<Tool>(),
            Documentation = new Documentation[]
            {
                new ("RadfordHound's NN Spec", "https://gist.github.com/Radfordhound/5650ef12209da2709a6bf9b705bdd79c", "RadfordHound")
            },
            Description = "",
            Example = "v.xng"
        },
        new()
        {
            Id = "NN-XNM",
            Extension = ".XNM",
            Category = "3D",
            Format = "Sega NN: Skeletal Animation [Xbox/Direct3D]",
            Tools = Array.Empty<Tool>(),
            Documentation = new Documentation[]
            {
                new ("RadfordHound's NN Spec", "https://gist.github.com/Radfordhound/5650ef12209da2709a6bf9b705bdd79c", "RadfordHound")
            },
            Description = "",
            Example = "v.xnm"
        },
        new()
        {
            Id = "NN-XNO",
            Extension = ".XNO",
            Category = "3D",
            Format = "Sega NN: 3D Object [Xbox/Direct3D]",
            Tools = new Tool[]
            {
                new Tool("Sega NN Tools", "https://github.com/Argx2121/Sega_NN_tools", "Arg!!", "Can Import/Export Models for Sonic Riders (PC, GCN) and Many More!!")
            },           
            Documentation = new Documentation[]
            {
                new ("RadfordHound's NN Spec", "https://gist.github.com/Radfordhound/5650ef12209da2709a6bf9b705bdd79c", "RadfordHound")
            },
            Description = "The model format for Sonic Riders' 3D Models",
            Example = "v.xno"
        },
        new()
        {
            Id = "NN-GNO",
            Extension = ".GNO",
            Category = "3D",
            Format = "Sega NN: 3D Object [GCN/GX]",
            Tools = new Tool[]
            {
                new Tool("Sega NN Tools", "https://github.com/Argx2121/Sega_NN_tools", "Arg!!", "Can Import/Export Models for Sonic Riders (PC, GCN) and Many More!!")
            },
            Documentation = new Documentation[]
            {
                new ("RadfordHound's NN Spec", "https://gist.github.com/Radfordhound/5650ef12209da2709a6bf9b705bdd79c", "RadfordHound")
            },
            Description = "The model format for Sonic Riders' 3D Models",
            Example = "v.xno"
        },
        new()
        {
            Id = "NN-XNV",
            Extension = ".XNV",
            Category = "3D",
            Format = "Sega NN: Material Animation [Xbox/Direct3D]",
            Tools = Array.Empty<Tool>(),
            Documentation = new Documentation[]
            {
                new ("RadfordHound's NN Spec", "https://gist.github.com/Radfordhound/5650ef12209da2709a6bf9b705bdd79c", "RadfordHound")
            },
            Description = "",
            Example = "v.xnv"
        },
        new()
        {
            Id = "PVR-XVRS",
            Extension = ".XVRS",
            Category = "Archive",
            Format = "PVR Texture Library [Xbox/Direct3D]",
            Tools = new Tool[]
            {
                new ("RidersTextureArchiveTool", "https://github.com/Sewer56/SonicRiders.Index/tree/master/Source/RidersTextureArchiveTool", "Sewer56", "Only unpacks/repacks the archive container. You will need to use other tools like Puyo Tools for texture conversion. [depending on platform]"),
                new ("Sega NN Tools", "https://github.com/Sewer56/SonicRiders.Index/tree/master/Source/RidersTextureArchiveTool", "Arg!!", "Can directly replace textures and/or convert them to/from DDS.")
            },
            Documentation = new Documentation[]
            {
                new ("XvrsTextureArchive.bt", "https://github.com/Sewer56/SonicRiders.Index/blob/master/docs/files/template/XvrsTextureArchive.bt", "Sewer56")
            },
            Description = "Container with multiple textures. For some strange reason they decided to use a file extension which made it look like it belongs to Sega NN library.",
            Example = "v.XVRs"
        },

        // Riders Specific Stuff
        new()
        {
            Id = "RIDERS-OBJLAYOUT",
            Category = "Game",
            Extension = null,
            CustomExtension = ".riders-object-layout",
            Format = "Object Layout Format",
            Tools = new Tool[]
            {
                new ("Riders.Tweakbox", "https://github.com/Sewer56/Riders.Tweakbox", "Sewer56", "Real Time Editor Integrated as part of the Sonic Riders PC Mod")
            },
            Documentation = new Documentation[]
            {
                new ("ObjectLayout.bt", "https://github.com/Sewer56/SonicRiders.Index/blob/master/docs/files/template/ObjectLayout.bt", "Sewer56")
            },
            Description = "Defines the layout of objects in Sonic Riders",
            Example = "1 -> 00305 -> 00000"
        },
        new()
        {
            Id = "RIDERS-OBJPORTAL",
            Category = "Game",
            Extension = null,
            CustomExtension = ".riders-visibility-layout",
            Format = "Object Visibility Layout Format",
            Tools = Array.Empty<Tool>(),
            Documentation = new Documentation[]
            {
                new ("ObjectVisibility.bt", "https://github.com/Sewer56/SonicRiders.Index/blob/master/docs/files/template/ObjectVisibility.bt", "Sewer56")
            },
            Description = "Defines object rendering regions. It contains a list of 3D bounding boxes objects indexed an ASCII character. If an object has the same character assigned but is not in the box, it is not loaded.",
            Example = "1 -> 00301 -> 00000"
        },
        new()
        {
            Id = "PVRT",
            Category = "Graphics",
            Extension = ".PVR",
            Format = "Texture Format",
            Tools = new Tool[]
            {
                new ("Puyo Tools", "https://github.com/nickworonekin/puyotools", "Various Contributors", "Supports many variants used in console versions of Riders."),
                new ("Sega NN Tools", "https://github.com/Argx2121/Sega_NN_tools", "Arg!!", "Supports some variants of PC formats.")
            },
            Description = "Variant of the classic Ninja PVRT format used on the Dreamcast.",
            Example = "Inside PVR Texture Libraries"
        }
    };
}