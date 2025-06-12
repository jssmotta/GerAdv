'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { ParceriaProcGridAdapter } from '@/app/GerAdv_TS/ParceriaProc/Adapter/ParceriaProcGridAdapter';
import ParceriaProcGridContainer from '@/app/GerAdv_TS/ParceriaProc/Components/ParceriaProcGridContainer';
const ParceriaProcPage: React.FC = () => {
  const ParceriaProcGrid = new ParceriaProcGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Parceria Proc' />
    <ParceriaProcGridContainer grid={ParceriaProcGrid} />
  </PageLayout>
);
};
export default ParceriaProcPage;