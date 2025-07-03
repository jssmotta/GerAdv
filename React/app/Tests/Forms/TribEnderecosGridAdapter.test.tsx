// TribEnderecosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { TribEnderecosGridAdapter } from '@/app/GerAdv_TS/TribEnderecos/Adapter/TribEnderecosGridAdapter';
// Mock TribEnderecosGrid component
jest.mock('@/app/GerAdv_TS/TribEnderecos/Crud/Grids/TribEnderecosGrid', () => () => <div data-testid='tribenderecos-grid-mock' />);
describe('TribEnderecosGridAdapter', () => {
  it('should render TribEnderecosGrid component', () => {
    const adapter = new TribEnderecosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('tribenderecos-grid-mock')).toBeInTheDocument();
  });
});