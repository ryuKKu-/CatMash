export class Cat {
    catId: string;
    imageUrl: string;
    name: string;
    rating: number;
    wins: number;
    looses: number;
    histories: History[];
}

export class History {
    historyId: number;
    date: string;
    rating: number;
    cat: Cat;
    match: Match;
}

export class Match {
    matchId: number;
    result: number;
    ratingA: number;
    ratingB: number;
    catA: Cat;
    catB: Cat;
}