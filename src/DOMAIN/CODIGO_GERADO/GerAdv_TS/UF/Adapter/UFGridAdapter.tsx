"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import UFGrid from "@/app/GerAdv_TS/UF/Crud/Grids/UFGrid";

export class UFGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <UFGrid />;
    }
}