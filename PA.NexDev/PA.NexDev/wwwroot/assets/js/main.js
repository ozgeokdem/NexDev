document.addEventListener('DOMContentLoaded', () => {
    // Mobile Menu Toggle
    const menuToggle = document.querySelector('.menu-toggle');
    const navLinks = document.querySelector('.nav-links');

    if (menuToggle) {
        menuToggle.addEventListener('click', () => {
            navLinks.classList.toggle('active');
        });
    }

    // Modal Logic for "Talep Formu"
    const modal = document.getElementById('requestModal');
    const modalBtns = document.querySelectorAll('.open-modal-btn');
    const closeBtn = document.querySelector('.modal-close');
    const projectInput = document.getElementById('requestedProject');

    if (modalBtns.length > 0 && modal) {
        modalBtns.forEach(btn => {
            btn.addEventListener('click', (e) => {
                e.preventDefault();
                // Get project title from data attribute or parent
                const projectTitle = btn.getAttribute('data-project');
                if (projectInput && projectTitle) {
                    projectInput.value = projectTitle;
                }
                modal.classList.add('active');
            });
        });

        closeBtn.addEventListener('click', () => {
            modal.classList.remove('active');
        });

        // Close modal when clicking outside
        window.addEventListener('click', (e) => {
            if (e.target === modal) {
                modal.classList.remove('active');
            }
        });
    }

    // Header scroll effect
    const header = document.querySelector('.header');
    window.addEventListener('scroll', () => {
        if (window.scrollY > 50) {
            header.style.background = 'rgba(15, 23, 42, 0.95)';
            header.style.boxShadow = '0 4px 20px rgba(0,0,0,0.2)';
        } else {
            header.style.background = 'rgba(15, 23, 42, 0.8)';
            header.style.boxShadow = 'none';
        }
    });
});
