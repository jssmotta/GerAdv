'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { DivisaoTribunalGridAdapter } from '@/app/GerAdv_TS/DivisaoTribunal/Adapter/DivisaoTribunalGridAdapter';
import DivisaoTribunalGridContainer from '@/app/GerAdv_TS/DivisaoTribunal/Components/DivisaoTribunalGridContainer';
const DivisaoTribunalPage: React.FC = () => {
  const DivisaoTribunalGrid = new DivisaoTribunalGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Divisao Tribunal' />
    <DivisaoTribunalGridContainer grid={DivisaoTribunalGrid} />
  </PageLayout>
);
};
export default DivisaoTribunalPage;