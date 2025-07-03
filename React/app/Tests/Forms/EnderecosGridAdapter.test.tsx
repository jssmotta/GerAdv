// EnderecosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { EnderecosGridAdapter } from '@/app/GerAdv_TS/Enderecos/Adapter/EnderecosGridAdapter';
// Mock EnderecosGrid component
jest.mock('@/app/GerAdv_TS/Enderecos/Crud/Grids/EnderecosGrid', () => () => <div data-testid='enderecos-grid-mock' />);
describe('EnderecosGridAdapter', () => {
  it('should render EnderecosGrid component', () => {
    const adapter = new EnderecosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('enderecos-grid-mock')).toBeInTheDocument();
  });
});