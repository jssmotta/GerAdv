// ServicosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ServicosGridAdapter } from '@/app/GerAdv_TS/Servicos/Adapter/ServicosGridAdapter';
// Mock ServicosGrid component
jest.mock('@/app/GerAdv_TS/Servicos/Crud/Grids/ServicosGrid', () => () => <div data-testid='servicos-grid-mock' />);
describe('ServicosGridAdapter', () => {
  it('should render ServicosGrid component', () => {
    const adapter = new ServicosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('servicos-grid-mock')).toBeInTheDocument();
  });
});