// ClientesSociosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ClientesSociosGridAdapter } from '@/app/GerAdv_TS/ClientesSocios/Adapter/ClientesSociosGridAdapter';
// Mock ClientesSociosGrid component
jest.mock('@/app/GerAdv_TS/ClientesSocios/Crud/Grids/ClientesSociosGrid', () => () => <div data-testid='clientessocios-grid-mock' />);
describe('ClientesSociosGridAdapter', () => {
  it('should render ClientesSociosGrid component', () => {
    const adapter = new ClientesSociosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('clientessocios-grid-mock')).toBeInTheDocument();
  });
});