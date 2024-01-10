
const MenuElements = [
    {
        'name': 'Header',
        'elements': [
            `<div style="display: flex; justify-content: flex-start; align-items: center; width: 100%; padding: 3%; gap: 3%; ">
                <a>Home</a>
                <a>About</a>
                <a>Collection</a>
                <a>Contact</a>
            </div>`,
            `<div style="display: flex; justify-content: flex-end; align-items: center; width: 100%; padding: 3%; gap: 3%; ">
                <a>Home</a>
                <a>About</a>
                <a>Collection</a>
                <a>Contact</a>
            </div>`,
            `<div style="display: flex; justify-content: center; align-items: center; width: 100%; padding: 3%; gap: 3%; ">
                <a>Home</a>
                <a>About</a>
                <a>Collection</a>
                <a>Contact</a>
            </div>`,
            `<div style="display: flex; justify-content: space-between; align-items: center; width: 100%; padding: 3%; gap: 20%; ">
                <a>Logo.</a>
                <div style='display: flex; justify-content: center; align-items: center; gap: 3%'>
                    <a>Home</a>
                    <a>About</a>
                    <a>Collection</a>
                    <a>Contact</a>
                </div>
            </div>`,
            `<div style="display: flex; justify-content: space-around; align-items: center; width: 100%; padding: 3%; gap: 20%; ">
                <a>Logo.</a>
                <div style='display: flex; justify-content: center; align-items: center; gap: 3%'>
                    <a>Home</a>
                    <a>About</a>
                    <a>Collection</a>
                    <a>Contact</a>
                </div>
            </div>`,
        ]
    }, 
    {
        'name': 'Intro',
        'elements': [
           `<div style="display: flex; justify-content: center; align-items: center; width: 100%; flex-direction:column; position: relative">
                <img 
                    src="/public/sunset.jpg" 
                    alt="Intro1" style="width: 100%; height: 100%; object-fit: cover; border-radius: 10px; opacity: .7"/>
                <div style="display: flex; justify-content: center; align-items: center; width: 100%; flex-direction:column; position:absolute; z-index: 2; padding: 5% 10%;" >
                    <h2 style="font-weight: bold; scale: 1.3; margin-bottom: 3%; color: white;">Header</h2>
                    <p style="line-height: 100%; text-align:center; color: white;" >Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                </div>
           </div>`,
           `<div style="display: flex; justify-content: center; align-items: start; width: 100%; flex-direction:column; position: relative">
                <img 
                    src="/public/sunset.jpg" 
                    alt="Intro1" style="width: 100%; height: 100%; object-fit: cover; border-radius: 10px; opacity: .7"/>
                <div style="display: flex; justify-content: center; align-items: center; width: 100%; flex-direction:column; position:absolute; z-index: 2; padding: 5% 10%; max-width: 70%" >
                    <h2 style="font-weight: bold; scale: 1.3; text-align: left; width: 100%; padding-left: 11%; margin-bottom: 3%; color: white;">Header</h2>
                    <p style="line-height: 100%; text-align: left; color: white;" >Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                </div>
            </div>`,
            `<div style="display: flex; justify-content: center; align-items: end; width: 100%; flex-direction:column; position: relative">
                <img 
                    src="/public/sunset.jpg" 
                    alt="Intro1" style="width: 100%; height: 100%; object-fit: cover; border-radius: 10px; opacity: .7"/>
                <div style="display: flex; justify-content: center; align-items: center; width: 100%; flex-direction:column; position:absolute; z-index: 2; padding: 5% 10%; max-width: 70%" >
                    <h2 style="font-weight: bold; scale: 1.3; text-align: right; width: 100%; padding-right: 11%; margin-bottom: 3%; color: white">Header</h2>
                    <p style="line-height: 100%; text-align: right; color: white;" >Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                </div>
            </div>`,
        ]
    },
    {
        'name': 'About',
        'elements': [
            `<div style="display: flex; justify-content: space-between; padding: 5%; align-items: center; width: 100%;">
            <img 
                src="/public/sunset.jpg" 
                alt="Intro1" style="width: 50%; height: 100%; object-fit: cover; border-radius: 10px;"/>
            <div style="display: flex; width: 50%; flex-direction:column;z-index: 2; padding: 5%;" >
                <h2 style="font-weight: bold; scale: 1.3; text-align:left; width: 100%; padding-left: 11%; margin-bottom: 2%;">Header</h2>
                <p style="line-height: 100%; text-align:left" >Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
            </div>
        </div>`,
        `<div style="display: flex; justify-content: space-between; padding: 5%; align-items: center; width: 100%;">
            <div style="display: flex; width: 50%; flex-direction:column;z-index: 2; padding: 5%;" >
                <h2 style="font-weight: bold; scale: 1.3; text-align:left; width: 100%; padding-left: 11%; margin-bottom: 2%;">Header</h2>
                <p style="line-height: 100%; text-align:left" >Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
            </div>
            <img 
                src="/public/sunset.jpg" 
                alt="Intro1" style="width: 50%; height: 100%; object-fit: cover; border-radius: 10px;"/>
        </div>`,
        ]
    },
    {
        'name': 'Cards',
        'elements': [
            `
            <div style="display: flex; justify-content: space-between; align-items: center;width: 100%; gap: 3%; margin-bottom: 10px; padding: 5%">
                <div style="display: flex; justify-content:center; align-items: center; flex-direction:column; width: 30%">
                    <img 
                    src="/public/sunset.jpg" 
                    alt="" 
                    style="width: 100%; border-radius: 6px" />
                    <h3>Card 1</h3>
                </div>
                <div style="display: flex; justify-content:center; align-items: center; flex-direction:column; width: 30%">
                    <img 
                        src="/public/sunset.jpg" 
                        alt=""
                        style="width: 100%; border-radius: 6px" />
                    <h3>Card 2</h3>
                </div>
                <div style="display: flex; justify-content:center; align-items: center; flex-direction:column; width: 30%">
                    <img 
                        src="/public/sunset.jpg" 
                        alt="" 
                        style="width: 100%; border-radius: 6px" />
                    <h3>Card 3</h3>
                </div>
                <div style="display: flex; justify-content:center; align-items: center; flex-direction:column; width: 30%">
                    <img 
                        src="/public/sunset.jpg" 
                        alt="" 
                        style="width: 100%; border-radius: 6px" />
                    <h3>Card 4</h3>
                </div>
            </div>
            `,
            `
            <div style="display: flex; justify-content: space-between; align-items: center;width: 100%; gap: 3%; margin-bottom: 10px; padding: 5%">
                <div style="display: flex; justify-content:center; align-items: center; flex-direction:column; width: 40%">
                    <img 
                    src="/public/sunset.jpg" 
                    alt="" 
                    style="width: 100%; border-radius: 6px" />
                    <h3>Card 1</h3>
                </div>
                <div style="display: flex; justify-content:center; align-items: center; flex-direction:column; width: 40%">
                    <img 
                        src="/public/sunset.jpg" 
                        alt=""
                        style="width: 100%; border-radius: 6px" />
                    <h3>Card 2</h3>
                </div>
                <div style="display: flex; justify-content:center; align-items: center; flex-direction:column; width: 40%">
                    <img 
                        src="/public/sunset.jpg" 
                        alt="" 
                        style="width: 100%; border-radius: 6px" />
                    <h3>Card 3</h3>
                </div>
            </div>
            `,
            `
            <div style="display: flex; justify-content: space-between; align-items: center;width: 100%; gap: 3%; margin-bottom: 10px; padding: 5%">
                <div style="display: flex; justify-content:center; align-items: center; flex-direction:column; width: 50%">
                    <img 
                    src="/public/sunset.jpg" 
                    alt="" 
                    style="width: 100%; border-radius: 6px" />
                    <h3>Card 1</h3>
                </div>
                <div style="display: flex; justify-content:center; align-items: center; flex-direction:column; width: 50%">
                    <img 
                        src="/public/sunset.jpg" 
                        alt=""
                        style="width: 100%; border-radius: 6px" />
                    <h3>Card 2</h3>
                </div>
            </div>
            `,
        ]
    },
    {
        'name': 'Footer',
        'elements': [
             `<div style="display: flex; justify-content: space-between; align-items: center; width: 100%; padding: 3%; gap: 3%; ">
                    <div style="display: flex; justify-content: center; align-items: center; gap: 3%" >
                        <a>Home</a>
                        <a>About</a>
                        <a>Collection</a>
                    </div>
                    <div style="display: flex; justify-content: center; align-items: center;" >
                        <a>example@gmail.com</a>
                    </div>
            </div>`
        ]
    }, 
]

export default MenuElements