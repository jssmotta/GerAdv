// ApensoGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ApensoGridAdapter } from '@/app/GerAdv_TS/Apenso/Adapter/ApensoGridAdapter';
// Mock ApensoGrid component
jest.mock('@/app/GerAdv_TS/Apenso/Crud/Grids/ApensoGrid', () => () => <div data-testid='apenso-grid-mock' />);
describe('ApensoGridAdapter', () => {
  it('should render ApensoGrid component', () => {
    const adapter = new ApensoGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('apenso-grid-mock')).toBeInTheDocument();
  });
});