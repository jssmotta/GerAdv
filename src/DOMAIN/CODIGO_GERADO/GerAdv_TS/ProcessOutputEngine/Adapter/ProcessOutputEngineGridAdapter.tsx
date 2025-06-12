'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ProcessOutputEngineGrid from '@/app/GerAdv_TS/ProcessOutputEngine/Crud/Grids/ProcessOutputEngineGrid';
export class ProcessOutputEngineGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ProcessOutputEngineGrid />;
  }
}