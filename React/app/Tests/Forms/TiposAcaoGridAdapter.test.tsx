// TiposAcaoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { TiposAcaoGridAdapter } from '@/app/GerAdv_TS/TiposAcao/Adapter/TiposAcaoGridAdapter';
// Mock TiposAcaoGrid component
jest.mock('@/app/GerAdv_TS/TiposAcao/Crud/Grids/TiposAcaoGrid', () => () => <div data-testid='tiposacao-grid-mock' />);
describe('TiposAcaoGridAdapter', () => {
  it('should render TiposAcaoGrid component', () => {
    const adapter = new TiposAcaoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('tiposacao-grid-mock')).toBeInTheDocument();
  });
});