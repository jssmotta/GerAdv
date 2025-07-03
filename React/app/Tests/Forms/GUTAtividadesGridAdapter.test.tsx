// GUTAtividadesGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { GUTAtividadesGridAdapter } from '@/app/GerAdv_TS/GUTAtividades/Adapter/GUTAtividadesGridAdapter';
// Mock GUTAtividadesGrid component
jest.mock('@/app/GerAdv_TS/GUTAtividades/Crud/Grids/GUTAtividadesGrid', () => () => <div data-testid='gutatividades-grid-mock' />);
describe('GUTAtividadesGridAdapter', () => {
  it('should render GUTAtividadesGrid component', () => {
    const adapter = new GUTAtividadesGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('gutatividades-grid-mock')).toBeInTheDocument();
  });
});