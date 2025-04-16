"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import NECompromissosGrid from "@/app/GerAdv_TS/NECompromissos/Crud/Grids/NECompromissosGrid";

export class NECompromissosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <NECompromissosGrid />;
    }
}