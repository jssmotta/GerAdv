// ProcessOutputRequestGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProcessOutputRequestGridAdapter } from '@/app/GerAdv_TS/ProcessOutputRequest/Adapter/ProcessOutputRequestGridAdapter';
// Mock ProcessOutputRequestGrid component
jest.mock('@/app/GerAdv_TS/ProcessOutputRequest/Crud/Grids/ProcessOutputRequestGrid', () => () => <div data-testid='processoutputrequest-grid-mock' />);
describe('ProcessOutputRequestGridAdapter', () => {
  it('should render ProcessOutputRequestGrid component', () => {
    const adapter = new ProcessOutputRequestGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('processoutputrequest-grid-mock')).toBeInTheDocument();
  });
});