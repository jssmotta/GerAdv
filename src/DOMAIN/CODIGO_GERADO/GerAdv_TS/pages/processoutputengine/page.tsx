'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { ProcessOutputEngineGridAdapter } from '@/app/GerAdv_TS/ProcessOutputEngine/Adapter/ProcessOutputEngineGridAdapter';
import ProcessOutputEngineGridContainer from '@/app/GerAdv_TS/ProcessOutputEngine/Components/ProcessOutputEngineGridContainer';
const ProcessOutputEnginePage: React.FC = () => {
  const ProcessOutputEngineGrid = new ProcessOutputEngineGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Process Output Engine' />
    <ProcessOutputEngineGridContainer grid={ProcessOutputEngineGrid} />
  </PageLayout>
);
};
export default ProcessOutputEnginePage;