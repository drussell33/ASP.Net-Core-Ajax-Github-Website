- Act as a Senior Software Engineer, Technical Writer, and Open Source Maintainer with 10+ years of experience.
- Your task is to analyze the following GitHub repository and generate a COMPLETE, production-quality README.md file.
- You must base everything ONLY on the actual contents of the repository (code, structure, dependencies, comments, config files, etc.). Do NOT fabricate features or technologies.

INPUT:
Repository URL: https://github.com/drussell33/ASP.Net-Core-Ajax-Github-Website

STRICT RULES (VERY IMPORTANT):
- The output must be written as a real README.md file (pure Markdown)
- DO NOT wrap the entire output in a markdown code block
- DO NOT explain anything outside the README
- DO NOT include commentary, notes, or explanations
- The output must be clean and directly usable as a README.md file
- At the END, you MUST generate a downloadable file using the python_user_visible tool
---------------------------------------
README REQUIREMENTS:

1. Project Title & Description
- Clear project name
- 2–3 sentence high-level professional summary

2. Badges (use shields.io)
- Repo size
- Last commit
- Top language
- License (only if repo has one)

3. Key Features
- Bullet list of real features based ONLY on the repo

4. Tech Stack
- Backend
- Frontend
- Database
- Tools / Services

5. Architecture Overview (IMPORTANT)
- Explain how frontend, backend, and database interact
- Mention patterns if visible (DTOs, services, DI, etc.)

6. Project Structure
- Tree-style directory layout
- Include short explanations of important folders

7. Getting Started

Prerequisites:
- Required tools and versions

Installation:
- Clone repo
- Install dependencies

Usage:
- Commands to run backend and frontend

8. Roadmap
- Use checklist format
- Include both implemented and logical next steps

9. Contributing
- Standard GitHub flow

10. Screenshots / Demo
- Placeholder section

11. License
- Only include if repo contains one

12. Contact
- GitHub profile link
---------------------------------------
OUTPUT FORMAT RULES:

- Use clean, professional Markdown
- Use headings (##, ###)
- Use code blocks ONLY where appropriate (bash, tree)
- Keep formatting consistent
- No emojis unless minimal and professional
---------------------------------------
FINAL STEP (CRITICAL):

After generating the README content:

- Use python_user_visible to create a file named:
  README.md

- Save the FULL README content into that file

- Return a download link like:
  [Download README](sandbox:/mnt/data/README.md)

---------------------------------------
QUALITY BAR:

The README should be:
- Comparable to top GitHub open source projects
- Clean, structured, and recruiter-friendly
- Immediately usable without edits


