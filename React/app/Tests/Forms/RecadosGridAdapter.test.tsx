// RecadosGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { RecadosGridAdapter } from '@/app/GerAdv_TS/Recados/Adapter/RecadosGridAdapter';
// Mock RecadosGrid component
jest.mock('@/app/GerAdv_TS/Recados/Crud/Grids/RecadosGrid', () => () => <div data-testid='recados-grid-mock' />);
describe('RecadosGridAdapter', () => {
  it('should render RecadosGrid component', () => {
    const adapter = new RecadosGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('recados-grid-mock')).toBeInTheDocument();
  });
});