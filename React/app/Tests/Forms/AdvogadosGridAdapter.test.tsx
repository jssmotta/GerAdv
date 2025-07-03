// AdvogadosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AdvogadosGridAdapter } from '@/app/GerAdv_TS/Advogados/Adapter/AdvogadosGridAdapter';
// Mock AdvogadosGrid component
jest.mock('@/app/GerAdv_TS/Advogados/Crud/Grids/AdvogadosGrid', () => () => <div data-testid='advogados-grid-mock' />);
describe('AdvogadosGridAdapter', () => {
  it('should render AdvogadosGrid component', () => {
    const adapter = new AdvogadosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('advogados-grid-mock')).toBeInTheDocument();
  });
});