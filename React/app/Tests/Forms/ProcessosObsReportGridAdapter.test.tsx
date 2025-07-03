// ProcessosObsReportGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProcessosObsReportGridAdapter } from '@/app/GerAdv_TS/ProcessosObsReport/Adapter/ProcessosObsReportGridAdapter';
// Mock ProcessosObsReportGrid component
jest.mock('@/app/GerAdv_TS/ProcessosObsReport/Crud/Grids/ProcessosObsReportGrid', () => () => <div data-testid='processosobsreport-grid-mock' />);
describe('ProcessosObsReportGridAdapter', () => {
  it('should render ProcessosObsReportGrid component', () => {
    const adapter = new ProcessosObsReportGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('processosobsreport-grid-mock')).toBeInTheDocument();
  });
});