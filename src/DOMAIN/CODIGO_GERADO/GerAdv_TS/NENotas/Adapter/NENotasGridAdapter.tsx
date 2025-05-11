"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import NENotasGrid from "@/app/GerAdv_TS/NENotas/Crud/Grids/NENotasGrid";

export class NENotasGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <NENotasGrid />;
    }
}