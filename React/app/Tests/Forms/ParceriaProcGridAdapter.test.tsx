// ParceriaProcGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ParceriaProcGridAdapter } from '@/app/GerAdv_TS/ParceriaProc/Adapter/ParceriaProcGridAdapter';
// Mock ParceriaProcGrid component
jest.mock('@/app/GerAdv_TS/ParceriaProc/Crud/Grids/ParceriaProcGrid', () => () => <div data-testid='parceriaproc-grid-mock' />);
describe('ParceriaProcGridAdapter', () => {
  it('should render ParceriaProcGrid component', () => {
    const adapter = new ParceriaProcGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('parceriaproc-grid-mock')).toBeInTheDocument();
  });
});