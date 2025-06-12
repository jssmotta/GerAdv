'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { GUTMatrizGridAdapter } from '@/app/GerAdv_TS/GUTMatriz/Adapter/GUTMatrizGridAdapter';
import GUTMatrizGridContainer from '@/app/GerAdv_TS/GUTMatriz/Components/GUTMatrizGridContainer';
const GUTMatrizPage: React.FC = () => {
  const GUTMatrizGrid = new GUTMatrizGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='G U T Matriz' />
    <GUTMatrizGridContainer grid={GUTMatrizGrid} />
  </PageLayout>
);
};
export default GUTMatrizPage;