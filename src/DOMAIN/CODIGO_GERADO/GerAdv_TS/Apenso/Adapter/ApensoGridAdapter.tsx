"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ApensoGrid from "@/app/GerAdv_TS/Apenso/Crud/Grids/ApensoGrid";

export class ApensoGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ApensoGrid />;
    }
}