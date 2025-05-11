"use client";
import { IGridComponent } from "@/app/interfaces/IGridComponent";
import EMPClassRiscosGrid from "@/app/GerAdv_TS/EMPClassRiscos/Crud/Grids/EMPClassRiscosGrid";

export class EMPClassRiscosGridAdapter implements IGridComponent {
    render(): React.ReactNode {
        return <EMPClassRiscosGrid />;
    }
}