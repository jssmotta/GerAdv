// TipoEMailGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { TipoEMailGridAdapter } from '@/app/GerAdv_TS/TipoEMail/Adapter/TipoEMailGridAdapter';
// Mock TipoEMailGrid component
jest.mock('@/app/GerAdv_TS/TipoEMail/Crud/Grids/TipoEMailGrid', () => () => <div data-testid='tipoemail-grid-mock' />);
describe('TipoEMailGridAdapter', () => {
  it('should render TipoEMailGrid component', () => {
    const adapter = new TipoEMailGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('tipoemail-grid-mock')).toBeInTheDocument();
  });
});