// TODO: define the Planet type
// What if planet type would be a tupple of Planet and orbit reference?
// Chanced naming to pascalCase
type Planet =
    | Mercury
    | Venus
    | Earth
    | Mars
    | Jupiter
    | Saturn
    | Uranus
    | Neptune

let howOldOnPlanet planetOrbit seconds =
    let earth = (float) seconds / 31557600.0
    earth / planetOrbit

let age (planet: Planet) (seconds: int64): float =
    let orbitReference =
        match planet with
        | Mercury -> 0.2408467
        | Venus -> 0.61519726
        | Earth -> 1.0
        | Mars -> 1.8808158
        | Jupiter -> 11.862615
        | Saturn -> 29.447498
        | Uranus -> 84.016846
        | Neptune -> 164.79132
    howOldOnPlanet orbitReference seconds

age Saturn 2000000000L