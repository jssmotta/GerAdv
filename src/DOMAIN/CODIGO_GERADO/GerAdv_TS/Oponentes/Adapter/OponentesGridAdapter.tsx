"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import OponentesGrid from "@/app/GerAdv_TS/Oponentes/Crud/Grids/OponentesGrid";

export class OponentesGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <OponentesGrid />;
    }
}