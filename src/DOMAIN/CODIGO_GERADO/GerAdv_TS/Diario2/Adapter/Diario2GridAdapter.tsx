"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import Diario2Grid from "@/app/GerAdv_TS/Diario2/Crud/Grids/Diario2Grid";

export class Diario2GridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <Diario2Grid />;
    }
}