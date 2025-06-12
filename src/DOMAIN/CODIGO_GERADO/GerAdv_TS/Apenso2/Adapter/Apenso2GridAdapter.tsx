'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import Apenso2Grid from '@/app/GerAdv_TS/Apenso2/Crud/Grids/Apenso2Grid';
export class Apenso2GridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <Apenso2Grid />;
  }
}