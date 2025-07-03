// ProcessOutPutIDsGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProcessOutPutIDsGridAdapter } from '@/app/GerAdv_TS/ProcessOutPutIDs/Adapter/ProcessOutPutIDsGridAdapter';
// Mock ProcessOutPutIDsGrid component
jest.mock('@/app/GerAdv_TS/ProcessOutPutIDs/Crud/Grids/ProcessOutPutIDsGrid', () => () => <div data-testid='processoutputids-grid-mock' />);
describe('ProcessOutPutIDsGridAdapter', () => {
  it('should render ProcessOutPutIDsGrid component', () => {
    const adapter = new ProcessOutPutIDsGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('processoutputids-grid-mock')).toBeInTheDocument();
  });
});