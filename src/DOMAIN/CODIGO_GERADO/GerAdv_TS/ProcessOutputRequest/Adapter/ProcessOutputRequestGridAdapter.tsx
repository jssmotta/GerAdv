"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import ProcessOutputRequestGrid from "@/app/GerAdv_TS/ProcessOutputRequest/Crud/Grids/ProcessOutputRequestGrid";

export class ProcessOutputRequestGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <ProcessOutputRequestGrid />;
    }
}