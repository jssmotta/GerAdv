'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ProcessosObsReportGrid from '@/app/GerAdv_TS/ProcessosObsReport/Crud/Grids/ProcessosObsReportGrid';
export class ProcessosObsReportGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ProcessosObsReportGrid />;
  }
}