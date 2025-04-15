"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import RecadosGrid from "@/app/GerAdv_TS/Recados/Crud/Grids/RecadosGrid";

export class RecadosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <RecadosGrid />;
    }
}