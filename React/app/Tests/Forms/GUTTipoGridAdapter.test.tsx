// GUTTipoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { GUTTipoGridAdapter } from '@/app/GerAdv_TS/GUTTipo/Adapter/GUTTipoGridAdapter';
// Mock GUTTipoGrid component
jest.mock('@/app/GerAdv_TS/GUTTipo/Crud/Grids/GUTTipoGrid', () => () => <div data-testid='guttipo-grid-mock' />);
describe('GUTTipoGridAdapter', () => {
  it('should render GUTTipoGrid component', () => {
    const adapter = new GUTTipoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('guttipo-grid-mock')).toBeInTheDocument();
  });
});