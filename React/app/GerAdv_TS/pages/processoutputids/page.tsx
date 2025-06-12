'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { ProcessOutPutIDsGridAdapter } from '@/app/GerAdv_TS/ProcessOutPutIDs/Adapter/ProcessOutPutIDsGridAdapter';
import ProcessOutPutIDsGridContainer from '@/app/GerAdv_TS/ProcessOutPutIDs/Components/ProcessOutPutIDsGridContainer';
const ProcessOutPutIDsPage: React.FC = () => {
  const ProcessOutPutIDsGrid = new ProcessOutPutIDsGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Process Out Put I Ds' />
    <ProcessOutPutIDsGridContainer grid={ProcessOutPutIDsGrid} />
  </PageLayout>
);
};
export default ProcessOutPutIDsPage;