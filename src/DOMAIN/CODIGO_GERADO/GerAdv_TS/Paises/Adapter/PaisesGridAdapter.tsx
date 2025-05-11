"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import PaisesGrid from "@/app/GerAdv_TS/Paises/Crud/Grids/PaisesGrid";

export class PaisesGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <PaisesGrid />;
    }
}