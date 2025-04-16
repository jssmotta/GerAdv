"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import JusticaGrid from "@/app/GerAdv_TS/Justica/Crud/Grids/JusticaGrid";

export class JusticaGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <JusticaGrid />;
    }
}