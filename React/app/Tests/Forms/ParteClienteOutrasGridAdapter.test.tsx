// ParteClienteOutrasGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ParteClienteOutrasGridAdapter } from '@/app/GerAdv_TS/ParteClienteOutras/Adapter/ParteClienteOutrasGridAdapter';
// Mock ParteClienteOutrasGrid component
jest.mock('@/app/GerAdv_TS/ParteClienteOutras/Crud/Grids/ParteClienteOutrasGrid', () => () => <div data-testid='parteclienteoutras-grid-mock' />);
describe('ParteClienteOutrasGridAdapter', () => {
  it('should render ParteClienteOutrasGrid component', () => {
    const adapter = new ParteClienteOutrasGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('parteclienteoutras-grid-mock')).toBeInTheDocument();
  });
});