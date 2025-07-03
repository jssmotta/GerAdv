// OperadorGruposGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { OperadorGruposGridAdapter } from '@/app/GerAdv_TS/OperadorGrupos/Adapter/OperadorGruposGridAdapter';
// Mock OperadorGruposGrid component
jest.mock('@/app/GerAdv_TS/OperadorGrupos/Crud/Grids/OperadorGruposGrid', () => () => <div data-testid='operadorgrupos-grid-mock' />);
describe('OperadorGruposGridAdapter', () => {
  it('should render OperadorGruposGrid component', () => {
    const adapter = new OperadorGruposGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('operadorgrupos-grid-mock')).toBeInTheDocument();
  });
});