USE [SDP2]
GO

INSERT INTO [dbo].[Categories] ([Name], [Description], [IsActive], [CreateAt], [UpdateAt])
VALUES 
('Science Fiction', 'Books about futuristic concepts, space exploration, and time travel.', 1, GETUTCDATE(), NULL),
('Programming & IT', 'Software development, coding languages, and IT infrastructure.', 1, GETUTCDATE(), NULL),
('Mathematics', 'Advanced and basic mathematics, algebra, and geometry.', 1, GETUTCDATE(), NULL),
('History', 'Historical events, civilizations, and world heritage.', 1, GETUTCDATE(), NULL),
('Self-Help', 'Personal development, motivation, and mental well-being.', 1, GETUTCDATE(), NULL),
('Psychology', 'Study of the human mind and behavior.', 1, GETUTCDATE(), NULL),
('Business & Economics', 'Finance, management, marketing, and economic theories.', 1, GETUTCDATE(), NULL),
('Biography', 'Life stories of famous and influential personalities.', 1, GETUTCDATE(), NULL),
('Mystery & Thriller', 'Suspenseful stories, crime investigations, and puzzles.', 1, GETUTCDATE(), NULL),
('Fantasy', 'Magical worlds, mythical creatures, and epic adventures.', 1, GETUTCDATE(), NULL),
('Romance', 'Stories focusing on love and emotional relationships.', 1, GETUTCDATE(), NULL),
('Poetry', 'Collections of poems and rhythmic literature.', 1, GETUTCDATE(), NULL),
('Philosophy', 'Fundamental nature of knowledge, reality, and existence.', 1, GETUTCDATE(), NULL),
('Medicine & Health', 'Medical science, nursing, and general healthcare tips.', 1, GETUTCDATE(), NULL),
('Law & Justice', 'Legal systems, constitutions, and human rights.', 1, GETUTCDATE(), NULL),
('Children''s Literature', 'Stories and educational books for young children.', 1, GETUTCDATE(), NULL),
('Travel & Geography', 'Travel guides, maps, and exploration of different places.', 1, GETUTCDATE(), NULL),
('Art & Architecture', 'Design, painting, sculpture, and building styles.', 1, GETUTCDATE(), NULL),
('Cookbooks & Food', 'Recipes, culinary techniques, and nutrition.', 1, GETUTCDATE(), NULL),
('Religion & Spirituality', 'Religious texts, theology, and spiritual guidance.', 1, GETUTCDATE(), NULL),
('Political Science', 'Government systems, public policies, and political theories.', 1, GETUTCDATE(), NULL),
('Environment & Nature', 'Ecology, climate change, and wildlife conservation.', 1, GETUTCDATE(), NULL),
('Engineering', 'Civil, mechanical, electrical, and other engineering fields.', 1, GETUTCDATE(), NULL),
('Drama & Plays', 'Theatrical scripts and dramatic performances.', 1, GETUTCDATE(), NULL),
('Graphic Novels', 'Visual storytelling through comics and illustrations.', 1, GETUTCDATE(), NULL),
('Health & Fitness', 'Physical exercise, yoga, and healthy lifestyle.', 1, GETUTCDATE(), NULL),
('Languages', 'Linguistics, grammar, and learning foreign languages.', 1, GETUTCDATE(), NULL),
('Sociology', 'Study of society, social institutions, and relationships.', 1, GETUTCDATE(), NULL),
('Sports & Recreation', 'Physical activities, sports history, and rules.', 1, GETUTCDATE(), NULL),
('Bengali Literature', 'Classic and contemporary literature in the Bengali language.', 1, GETUTCDATE(), NULL);
GO