let data: number | string ;


data = '42';
data = 42;

interface ICar {
    color: string;
    model: string;
    toSpeed?: number;
};

const car1 : ICar = {
    color: 'blue',
    model: 'bmw'
};

const car2 : ICar = {
    color: 'red',
    model: 'mercedes',
    toSpeed: 100
};

const multiply = (x: number, y: number): number =>  {
    return x * y;
};

