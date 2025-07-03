// ProProcuradoresGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProProcuradoresGridAdapter } from '@/app/GerAdv_TS/ProProcuradores/Adapter/ProProcuradoresGridAdapter';
// Mock ProProcuradoresGrid component
jest.mock('@/app/GerAdv_TS/ProProcuradores/Crud/Grids/ProProcuradoresGrid', () => () => <div data-testid='proprocuradores-grid-mock' />);
describe('ProProcuradoresGridAdapter', () => {
  it('should render ProProcuradoresGrid component', () => {
    const adapter = new ProProcuradoresGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('proprocuradores-grid-mock')).toBeInTheDocument();
  });
});