/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_webpages_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MediaAlbums]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaAlbums](
	[IDAlbum] [int] NOT NULL,
	[AlbumTitle] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_MediaAlbums] PRIMARY KEY CLUSTERED 
(
	[IDAlbum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[IDCountry] [bigint] NOT NULL,
	[CountryName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[IDCountry] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUs](
	[IDMessage] [bigint] NOT NULL,
	[MessageDateTime] [nvarchar](25) NULL,
	[MessageDateTimeGregorian] [datetime] NULL,
	[PersonFullName] [nvarchar](200) NULL,
	[Mobile] [nvarchar](20) NULL,
	[EMail] [nvarchar](100) NULL,
	[WebSite] [nvarchar](100) NULL,
	[MessageSubject] [nvarchar](100) NULL,
	[MessageBody] [nvarchar](2000) NULL,
	[IsRead] [bit] NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[IDMessage] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyInfo]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyInfo](
	[IDWebsite] [bigint] NOT NULL,
	[PositionName] [nvarchar](50) NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[ManagerName] [nvarchar](50) NOT NULL,
	[PhoneLine1] [nvarchar](50) NOT NULL,
	[PhoneLine2] [nvarchar](50) NOT NULL,
	[PhoneLine3] [nvarchar](50) NOT NULL,
	[CompanyAddress] [nvarchar](300) NOT NULL,
	[ThumnailMapPath] [nvarchar](500) NOT NULL,
	[GoogleMapScript] [nvarchar](max) NOT NULL,
	[ExtraMessage] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_CompanyInfo] PRIMARY KEY CLUSTERED 
(
	[IDWebsite] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SitePages]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SitePages](
	[IDPage] [int] NOT NULL,
	[PageInternalName] [nvarchar](50) NULL,
	[PageTitle] [nvarchar](100) NULL,
	[PageContent] [nvarchar](max) NULL,
	[HasFragments] [bit] NULL,
	[Published] [bit] NOT NULL,
	[IsMetaEditable] [bit] NOT NULL,
	[IsScript] [bit] NOT NULL,
 CONSTRAINT [PK_SitePages] PRIMARY KEY CLUSTERED 
(
	[IDPage] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SitePages] ([IDPage], [PageInternalName], [PageTitle], [PageContent], [HasFragments], [Published], [IsMetaEditable], [IsScript]) VALUES (1, N'ContactUsMessage', N'ارتباط با ما', N'آدرس : اهواز - نبوت - خیابان حافظ یک پلاک 42<br/>تلفن: 06132275484', 0, 1, 1, 0)
INSERT [dbo].[SitePages] ([IDPage], [PageInternalName], [PageTitle], [PageContent], [HasFragments], [Published], [IsMetaEditable], [IsScript]) VALUES (2, N'AboutPage', N'درباره ما', N'شرکت رویا پژوهش ', 0, 1, 1, 0)
/****** Object:  Table [dbo].[MediaTypes]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaTypes](
	[IDMediaType] [int] NOT NULL,
	[MediaTypeTitle] [nvarchar](50) NOT NULL,
	[ResourcesPrefix] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MediaTypes] PRIMARY KEY CLUSTERED 
(
	[IDMediaType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[MediaTypes] ([IDMediaType], [MediaTypeTitle], [ResourcesPrefix]) VALUES (1, N'ویدیو', N'Video')
INSERT [dbo].[MediaTypes] ([IDMediaType], [MediaTypeTitle], [ResourcesPrefix]) VALUES (2, N'عکس', N'Image')
/****** Object:  Table [dbo].[Sliders]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sliders](
	[IDSlider] [int] NOT NULL,
	[InternalName] [nvarchar](100) NOT NULL,
	[SliderWith] [nvarchar](10) NOT NULL,
	[SliderHeight] [nvarchar](10) NOT NULL,
	[Published] [bit] NOT NULL,
 CONSTRAINT [PK_Sliders] PRIMARY KEY CLUSTERED 
(
	[IDSlider] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SliderImages]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SliderImages](
	[SliderID] [int] NOT NULL,
	[SlideIndex] [int] NOT NULL,
	[ThumbnailImagePath] [nvarchar](500) NOT NULL,
	[ImagePath] [nvarchar](500) NOT NULL,
	[SlideTitle] [nvarchar](100) NOT NULL,
	[SlideDescription] [nvarchar](500) NOT NULL,
	[Published] [bit] NOT NULL,
 CONSTRAINT [PK_SliderImages] PRIMARY KEY CLUSTERED 
(
	[SliderID] ASC,
	[SlideIndex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MediaGallery]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaGallery](
	[IDGalleryItem] [int] NOT NULL,
	[AlbumID] [int] NULL,
	[ItemTitle] [nvarchar](100) NOT NULL,
	[ThumbnailImagePath] [nvarchar](max) NOT NULL,
	[ResourcePath] [nvarchar](max) NULL,
	[ItemDescription] [nvarchar](500) NULL,
	[MediaTypeID] [int] NOT NULL,
	[Published] [bit] NOT NULL,
	[SortOrder] [int] NOT NULL,
	[MediaTags] [nvarchar](300) NULL,
 CONSTRAINT [PK_MediaGallery] PRIMARY KEY CLUSTERED 
(
	[IDGalleryItem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SitePageFragments]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SitePageFragments](
	[PageID] [int] NOT NULL,
	[FragmentIndex] [int] NOT NULL,
	[PageContent] [nvarchar](max) NULL,
 CONSTRAINT [PK_SitePageFragments] PRIMARY KEY CLUSTERED 
(
	[PageID] ASC,
	[FragmentIndex] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provinces]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provinces](
	[CountryID] [bigint] NOT NULL,
	[IDProvince] [bigint] NOT NULL,
	[ProvinceName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Provinces] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC,
	[IDProvince] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 03/30/2016 21:12:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[CountryID] [bigint] NOT NULL,
	[ProvinceID] [bigint] NOT NULL,
	[IDCity] [bigint] NOT NULL,
	[CityName] [nvarchar](200) NOT NULL,
	[Latitude] [nvarchar](50) NULL,
	[Longitude] [nvarchar](50) NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC,
	[ProvinceID] ASC,
	[IDCity] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IDUser] [int] NOT NULL,
	[UserFullName] [nvarchar](200) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[EMail] [nvarchar](100) NOT NULL,
	[RegisterationDateTime] [nvarchar](25) NOT NULL,
	[RegisterationDateTimeGregorian] [datetime] NOT NULL,
	[Telephone] [nvarchar](20) NULL,
	[Mobile] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[WebAddress] [nvarchar](200) NOT NULL,
	[AddressCountryID] [bigint] NOT NULL,
	[AddressProvinceID] [bigint] NOT NULL,
	[AddressCityID] [bigint] NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[IsEmployee] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[IDUser] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserID] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_webpages_UsersInRoles] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 03/30/2016 21:13:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserID] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL CONSTRAINT [DF_webpages_Membership_IsConfirmed]  DEFAULT ((0)),
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL CONSTRAINT [DF_webpages_Membership_PasswordFailuresSinceLastSuccess]  DEFAULT ((0)),
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
 CONSTRAINT [PK_webpages_Membership] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Cities_Provinces]    Script Date: 03/30/2016 21:12:59 ******/
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Provinces] FOREIGN KEY([CountryID], [ProvinceID])
REFERENCES [dbo].[Provinces] ([CountryID], [IDProvince])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_Provinces]
GO
/****** Object:  ForeignKey [FK_MediaGallery_MediaAlbums]    Script Date: 03/30/2016 21:13:00 ******/
ALTER TABLE [dbo].[MediaGallery]  WITH CHECK ADD  CONSTRAINT [FK_MediaGallery_MediaAlbums] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[MediaAlbums] ([IDAlbum])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[MediaGallery] CHECK CONSTRAINT [FK_MediaGallery_MediaAlbums]
GO
/****** Object:  ForeignKey [FK_MediaGallery_MediaTypes]    Script Date: 03/30/2016 21:13:00 ******/
ALTER TABLE [dbo].[MediaGallery]  WITH CHECK ADD  CONSTRAINT [FK_MediaGallery_MediaTypes] FOREIGN KEY([MediaTypeID])
REFERENCES [dbo].[MediaTypes] ([IDMediaType])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[MediaGallery] CHECK CONSTRAINT [FK_MediaGallery_MediaTypes]
GO
/****** Object:  ForeignKey [FK_Provinces_Countries]    Script Date: 03/30/2016 21:13:00 ******/
ALTER TABLE [dbo].[Provinces]  WITH CHECK ADD  CONSTRAINT [FK_Provinces_Countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([IDCountry])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Provinces] CHECK CONSTRAINT [FK_Provinces_Countries]
GO
/****** Object:  ForeignKey [FK_SitePageFragments_SitePages]    Script Date: 03/30/2016 21:13:00 ******/
ALTER TABLE [dbo].[SitePageFragments]  WITH CHECK ADD  CONSTRAINT [FK_SitePageFragments_SitePages] FOREIGN KEY([PageID])
REFERENCES [dbo].[SitePages] ([IDPage])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SitePageFragments] CHECK CONSTRAINT [FK_SitePageFragments_SitePages]
GO
/****** Object:  ForeignKey [FK_SliderImages_Sliders]    Script Date: 03/30/2016 21:13:00 ******/
ALTER TABLE [dbo].[SliderImages]  WITH CHECK ADD  CONSTRAINT [FK_SliderImages_Sliders] FOREIGN KEY([SliderID])
REFERENCES [dbo].[Sliders] ([IDSlider])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SliderImages] CHECK CONSTRAINT [FK_SliderImages_Sliders]
GO
/****** Object:  ForeignKey [FK_Users_Cities]    Script Date: 03/30/2016 21:13:00 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Cities] FOREIGN KEY([AddressCountryID], [AddressProvinceID], [AddressCityID])
REFERENCES [dbo].[Cities] ([CountryID], [ProvinceID], [IDCity])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Cities]
GO
/****** Object:  ForeignKey [FK_webpages_Membership_Users]    Script Date: 03/30/2016 21:13:00 ******/
ALTER TABLE [dbo].[webpages_Membership]  WITH CHECK ADD  CONSTRAINT [FK_webpages_Membership_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([IDUser])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[webpages_Membership] CHECK CONSTRAINT [FK_webpages_Membership_Users]
GO
/****** Object:  ForeignKey [FK_webpages_UsersInRoles_Users]    Script Date: 03/30/2016 21:13:00 ******/
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_webpages_UsersInRoles_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([IDUser])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [FK_webpages_UsersInRoles_Users]
GO
/****** Object:  ForeignKey [FK_webpages_UsersInRoles_webpages_Roles]    Script Date: 03/30/2016 21:13:00 ******/
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_webpages_UsersInRoles_webpages_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [FK_webpages_UsersInRoles_webpages_Roles]
GO
