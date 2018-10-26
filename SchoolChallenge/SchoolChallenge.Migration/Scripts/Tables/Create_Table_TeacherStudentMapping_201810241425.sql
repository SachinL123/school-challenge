
CREATE TABLE [dbo].[TeacherStudentMapping](
	[TeacherStudentMappingId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NULL,
	[StudentId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_TeacherStudentMapping] PRIMARY KEY CLUSTERED 
(
	[TeacherStudentMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TeacherStudentMapping]  WITH CHECK ADD  CONSTRAINT [FK_TeacherStudentMapping_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
GO

ALTER TABLE [dbo].[TeacherStudentMapping] CHECK CONSTRAINT [FK_TeacherStudentMapping_Students]
GO

ALTER TABLE [dbo].[TeacherStudentMapping]  WITH CHECK ADD  CONSTRAINT [FK_TeacherStudentMapping_Teachers] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
GO

ALTER TABLE [dbo].[TeacherStudentMapping] CHECK CONSTRAINT [FK_TeacherStudentMapping_Teachers]
GO


