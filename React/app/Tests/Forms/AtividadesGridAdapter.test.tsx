// AtividadesGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AtividadesGridAdapter } from '@/app/GerAdv_TS/Atividades/Adapter/AtividadesGridAdapter';
// Mock AtividadesGrid component
jest.mock('@/app/GerAdv_TS/Atividades/Crud/Grids/AtividadesGrid', () => () => <div data-testid='atividades-grid-mock' />);
describe('AtividadesGridAdapter', () => {
  it('should render AtividadesGrid component', () => {
    const adapter = new AtividadesGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('atividades-grid-mock')).toBeInTheDocument();
  });
});