
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
                    src="https://images.unsplash.com/photo-1461696114087-397271a7aedc?q=80&w=2670&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" 
                    alt="Intro1" style="width: 100%; height: 100%; object-fit: cover; border-radius: 10px; opacity: .6"/>
                <div style="display: flex; justify-content: center; align-items: center; width: 100%; flex-direction:column; position:absolute; z-index: 2; padding: 5% 10%;" >
                    <h2 style="font-weight: bold; scale: 1.3; margin-bottom: 3%;">Lorem ipsum dolor sit amet.</h2>
                    <p style="line-height: 100%;" >Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                </div>
           </div>`,
        ]
    },
    {
        'name': 'About',
        'elements': [

        ]
    },
    {
        'name': 'Footer',
        'elements': [
             `<div style="display: flex; justify-content: space-between; align-items: center; width: 100%; padding: 0 3%; gap: 3%; ">
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