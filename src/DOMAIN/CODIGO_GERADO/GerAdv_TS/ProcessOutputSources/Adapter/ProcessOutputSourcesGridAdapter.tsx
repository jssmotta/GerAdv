'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ProcessOutputSourcesGrid from '@/app/GerAdv_TS/ProcessOutputSources/Crud/Grids/ProcessOutputSourcesGrid';
export class ProcessOutputSourcesGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ProcessOutputSourcesGrid />;
  }
}