// ProcessOutputSourcesGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProcessOutputSourcesGridAdapter } from '@/app/GerAdv_TS/ProcessOutputSources/Adapter/ProcessOutputSourcesGridAdapter';
// Mock ProcessOutputSourcesGrid component
jest.mock('@/app/GerAdv_TS/ProcessOutputSources/Crud/Grids/ProcessOutputSourcesGrid', () => () => <div data-testid='processoutputsources-grid-mock' />);
describe('ProcessOutputSourcesGridAdapter', () => {
  it('should render ProcessOutputSourcesGrid component', () => {
    const adapter = new ProcessOutputSourcesGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('processoutputsources-grid-mock')).toBeInTheDocument();
  });
});