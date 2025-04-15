"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import EndTitGrid from "@/app/GerAdv_TS/EndTit/Crud/Grids/EndTitGrid";

export class EndTitGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <EndTitGrid />;
    }
}