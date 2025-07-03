// GUTAtividadesMatrizGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { GUTAtividadesMatrizGridAdapter } from '@/app/GerAdv_TS/GUTAtividadesMatriz/Adapter/GUTAtividadesMatrizGridAdapter';
// Mock GUTAtividadesMatrizGrid component
jest.mock('@/app/GerAdv_TS/GUTAtividadesMatriz/Crud/Grids/GUTAtividadesMatrizGrid', () => () => <div data-testid='gutatividadesmatriz-grid-mock' />);
describe('GUTAtividadesMatrizGridAdapter', () => {
  it('should render GUTAtividadesMatrizGrid component', () => {
    const adapter = new GUTAtividadesMatrizGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('gutatividadesmatriz-grid-mock')).toBeInTheDocument();
  });
});