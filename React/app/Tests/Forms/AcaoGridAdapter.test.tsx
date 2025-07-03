// AcaoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AcaoGridAdapter } from '@/app/GerAdv_TS/Acao/Adapter/AcaoGridAdapter';
// Mock AcaoGrid component
jest.mock('@/app/GerAdv_TS/Acao/Crud/Grids/AcaoGrid', () => () => <div data-testid='acao-grid-mock' />);
describe('AcaoGridAdapter', () => {
  it('should render AcaoGrid component', () => {
    const adapter = new AcaoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('acao-grid-mock')).toBeInTheDocument();
  });
});