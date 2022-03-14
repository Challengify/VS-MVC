class TimeChart extends HTMLElement {
    degToRadians(angle) {
        return angle * (Math.PI / 180);
    }

    constructor() {
        super();

        const shadow = this.attachShadow({mode: 'open'});

        const wrapper = document.createElement('div');
        wrapper.setAttribute('class', 'time-chart-wrapper');

        const clipPathed1 = document.createElement('div');
        clipPathed1.setAttribute('class', 'time-chart-clip-pathed-1');

        const clipPathed2 = document.createElement('div');
        clipPathed2.setAttribute('class', 'time-chart-clip-pathed-2');

        const clipPathed3 = document.createElement('div');
        clipPathed3.setAttribute('class', 'time-chart-clip-pathed-3');

        const clipPathed4 = document.createElement('div');
        clipPathed4.setAttribute('class', 'time-chart-clip-pathed-4');

        var percent = this.getAttribute('percent');
        var clipPath1, clipPath2, clipPath3, clipPath4;
        clipPath1 = clipPath2 = clipPath3 = clipPath4 = 'none';

        if (percent <= 12.5) {
            clipPath1 = `polygon(0 0, 0% 100%, ${100*Math.tan(this.degToRadians(percent*3.6))}% 0)`;
        }
        else if (percent <= 25) {
            clipPath1 = `polygon(0 0, 100% 0, 100% ${100*Math.tan(this.degToRadians(percent*3.6-45))}%, 0% 100%)`;
        }
        else if (percent <= 37.5) {
            clipPath1 = `polygon(0 0, 100% 0, 100% 100%, 0% 100%)`;
            clipPath2 = `polygon(0 0, 100% ${100*Math.tan(this.degToRadians(percent*3.6-90))}%, 100% 0)`;
        }
        else if (percent <= 50) {
            clipPath1 = `polygon(0 0, 100% 0, 100% 100%, 0% 100%)`;
            clipPath2 = `polygon(0 0, 100% 0, 100% 100%, ${100 - 100*Math.tan(this.degToRadians(percent*3.6-135))}% 100%)`;
        }
        else if (percent <= 62.5) {
            clipPath1 = `polygon(0 0, 100% 0, 100% 100%, 0% 100%)`;
            clipPath2 = `polygon(0 0, 100% 0, 100% 100%, 0% 100%)`;
            clipPath3 = `polygon(${100 - 100*Math.tan(this.degToRadians(percent*3.6-180))}% 100%, 100% 100%, 100% 0)`;
        }
        else if (percent <= 75) {
            clipPath1 = `polygon(0 0, 100% 0, 100% 100%, 0% 100%)`;
            clipPath2 = `polygon(0 0, 100% 0, 100% 100%, 0% 100%)`;
            clipPath3 = `polygon(0 ${100 - 100*Math.tan(this.degToRadians(percent*3.6-225))}%, 100% 0, 100% 100%, 0% 100%)`;
        }
        else if (percent <= 87.5) {
            clipPath1 = `polygon(0 0, 100% 0, 100% 100%, 0% 100%)`;
            clipPath2 = `polygon(0 0, 100% 0, 100% 100%, 0% 100%)`;
            clipPath3 = `polygon(0 0, 100% 0, 100% 100%, 0% 100%)`;
            clipPath4 = `polygon(0 ${100 - 100*Math.tan(this.degToRadians(percent*3.6-270))}%, 0 100%, 100% 100%)`;
        }
        else if (percent <= 100) {
            clipPath1 = `polygon(0 0, 100% 0, 100% 100%, 0% 100%)`;
            clipPath2 = `polygon(0 0, 100% 0, 100% 100%, 0% 100%)`;
            clipPath3 = `polygon(0 0, 100% 0, 100% 100%, 0% 100%)`;
            clipPath4 = `polygon(0 0, ${100*Math.tan(this.degToRadians(percent*3.6-315))}% 0, 100% 100%, 0 100%)`;
        }

        const style = document.createElement('style');

        style.textContent = `
            .time-chart-wrapper {
                width: 100px;
                height: 100px;
                border: 15px solid #EEE9FA;
                position: relative;
                margin-left: 30px;
                margin-top: 20px;
                overflow: hidden;
                transform: rotate(-45deg);
            }

            .time-chart-clip-pathed-1 {
                position: absolute;
                top: 4px;
                left: 69px;
                width: 91.92px;
                height: 91.92px;
                background-color: #EEE9FA;
                transform: rotate(45deg);
                clip-path: ${clipPath1};
            }

            .time-chart-clip-pathed-2 {
                position: absolute;
                display: ${clipPath2 == 'none' ? 'none' : 'block'};
                top: 69px;
                left: 4px;
                width: 91.92px;
                height: 91.92px;
                background-color: #EEE9FA;
                transform: rotate(45deg);
                clip-path: ${clipPath2};
            }

            .time-chart-clip-pathed-3 {
                position: absolute;
                display: ${clipPath3 == 'none' ? 'none' : 'block'};
                top: 4px;
                left: -61px;
                width: 91.92px;
                height: 91.92px;
                background-color: #EEE9FA;
                transform: rotate(45deg);
                clip-path: ${clipPath3};
            }

            .time-chart-clip-pathed-4 {
                position: absolute;
                display: ${clipPath4 == 'none' ? 'none' : 'block'};
                top: -61px;
                left: 4px;
                width: 91.92px;
                height: 91.92px;
                background-color: #EEE9FA;
                transform: rotate(45deg);
                clip-path: ${clipPath4};
            }
        `;

        shadow.appendChild(style);
        shadow.appendChild(wrapper);
        wrapper.appendChild(clipPathed1);
        wrapper.appendChild(clipPathed2);
        wrapper.appendChild(clipPathed3);
        wrapper.appendChild(clipPathed4);
    }
}

customElements.define('time-chart', TimeChart);